using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	private const float SPEED = 5f;

	[SerializeField]
	private SphereCollider sphereCollider;
	[SerializeField]
	private Renderer sphereRenderer;

	private Utils.INode root;

	private void Awake()
	{
		BuildTree();
	}

	private void Update()
	{
		UpdateSphere();
		if (Input.GetKey(KeyCode.RightArrow)) {
			sphereCollider.transform.position += SPEED * Time.deltaTime * Vector3.right;
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			sphereCollider.transform.position -= SPEED * Time.deltaTime * Vector3.right;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			sphereCollider.transform.position += SPEED * Time.deltaTime * Vector3.up;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			sphereCollider.transform.position += SPEED * Time.deltaTime * Vector3.down;
		}
	}

	private void UpdateSphere()
	{
		TraverseNode(root, sphereCollider.transform.position);
	}

	private void BuildTree()
	{
		// 1
		root = new Utils.BSPNode(
			new Utils.Plane(Vector3.right, 0f),
			new Utils.BSPNode(
				new Utils.Plane(Vector3.up, 0f),
				Utils.BSPNode.CreateLeaf(ChangeColorRed),
				Utils.BSPNode.CreateLeaf(ChangeColorBlue),
				null
				),
			new Utils.BSPNode(
				new Utils.Plane(Vector3.up, 0f),
				Utils.BSPNode.CreateLeaf(ChangeColorGreen),
				Utils.BSPNode.CreateLeaf(ChangeColorYellow),
				null
				),
			null
		);
	}

	private void TraverseNode(Utils.INode node, Vector3 p)
	{
		if (node == null) {
			return;
		}

		if (!node.IsLeaf()) {
			TraverseNode(node.GetNext(p), p);
		}

		node.Execute();
	}

	private void ChangeColorRed()
	{
		sphereRenderer.material.SetColor("_Color", Color.red);
	}

	private void ChangeColorBlue()
	{
		sphereRenderer.material.SetColor("_Color", Color.blue);
	}

	private void ChangeColorGreen()
	{
		sphereRenderer.material.SetColor("_Color", Color.green);
	}

	private void ChangeColorYellow()
	{
		sphereRenderer.material.SetColor("_Color", Color.yellow);
	}
}
