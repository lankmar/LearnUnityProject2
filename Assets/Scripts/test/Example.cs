using UnityEngine;

namespace Assets.Scripts
{
	public class Example : MonoBehaviour
	{
		public Animator animator;

		public bool ikActive = false;
		public Transform rightHandObj = null;
		public Transform LookObj = null;

		private void OnValidate()
		{
			animator = GetComponent<Animator>();
		}

		//a callback for calculating IK
		private void OnAnimatorIK()
		{
			if (!animator) return;
			//if the IK is active, set the position and rotation directly to the goal. 
			if (ikActive)
			{
				// Set the look target position, if one has been assigned
				if (LookObj != null)
				{
					animator.SetLookAtWeight(1);
					animator.SetLookAtPosition(LookObj.position);
				}

				if (rightHandObj)
				{
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
					animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
				}
					
			}
			else
			{
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
				animator.SetLookAtWeight(0);
			}
		}
	}
}