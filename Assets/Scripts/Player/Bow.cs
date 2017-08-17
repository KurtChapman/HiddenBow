using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using HB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Bow : MonoBehaviour {

	 public GameObject Arrow;

	 enum BowState
	 {
		  Idle,
		  Drawing
	 };
	 BowState currentState = BowState.Idle;
	 GameInput mouseInput;
	 BowView bowView;

	 private void Start()
	 {
		  mouseInput = new GameInput();
		  bowView = new BowView(gameObject.transform);
	 }

	 // Update is called once per frame
	 void Update()
	 {
		  HandleMouseState();
		  UpdateBowState();
	 }

	 private void HandleMouseState()
	 {
		  if (PlayerDrawingBow())
		  {
				UpdateState(BowState.Drawing);
		  }
		  else if(mouseInput.Released)
		  {
				 UpdateState(BowState.Idle);
		  }
	 }

	 private void UpdateBowState()
	 {
		  if (currentState == BowState.Drawing)
		  {
				bowView.UpdateWithMousePos(mouseInput.Position);
		  }
	 }

	 private bool PlayerDrawingBow()
	 {
		  return mouseInput.Pressed && Utils.ClickedOnObject(gameObject, mouseInput.GetWorldSpacePosition);
	 }

	 private void UpdateState(BowState newState)
	 {
		  switch (newState)
		  {
				case BowState.Idle:
					 HandleIdleTransition();
					 break;
				case BowState.Drawing:
					 HandleDrawingTransition();
					 break;
				default:
					 break;
		  }

		  currentState = newState;
	 }

	 private void HandleIdleTransition()
	 {
		  if(currentState == BowState.Drawing)
		  {
				FireBow();
		  }
	 }

	 private Vector3 CalculateArrowDirection()
	 {
		  var direction = transform.position - mouseInput.GetWorldSpacePosition;
		  direction.Normalize();
		  return direction;
	 }

	 private Quaternion CalculateArrowRotation()
	 {
		  var dir = mouseInput.GetWorldSpacePosition - transform.position;
		  var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		  Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		  return rotation;
	 }

	 private void FireBow()
	 {
		  var arrowRotation = CalculateArrowRotation();
		  var arrow = Instantiate(Arrow, transform.position, arrowRotation);
		  Arrow arrowScript = arrow.GetComponent<Arrow>();
		  var arrowDirection = CalculateArrowDirection();
		  arrowScript.BeginFire(arrowDirection);
	 }

	 private void HandleDrawingTransition()
	 {
		  if (currentState == BowState.Idle)
				HandleBowDraw();
	 }


	 private void HandleBowDraw()
	 {
		  bowView.ShowPowerIndicator(mouseInput.Position);
	 }
}
