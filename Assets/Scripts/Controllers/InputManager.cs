using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class InputManager : MonoBehaviour
    {
        #region Variables       

        [Header("Controller Input")]
        public string horizontalInput = "Horizontal";
        public string verticallInput = "Vertical";
        public KeyCode jumpInput = KeyCode.Space;
        public KeyCode strafeInput = KeyCode.Tab;
        public KeyCode sprintInput = KeyCode.LeftShift;
        public KeyCode attackInput = KeyCode.Mouse0;

        [Header("Camera Input")]
        public string rotateCameraXInput = "Mouse X";
        public string rotateCameraYInput = "Mouse Y";
        public KeyCode actionInput = KeyCode.E;
        public KeyCode pauseInput = KeyCode.Escape;
        public KeyCode hpPotionActivation = KeyCode.Q;
        public KeyCode staminaPotionActivation = KeyCode.F2;

        [HideInInspector] public MovementCharController charMovement;
        [HideInInspector] public CameraController tpCamera;
        [HideInInspector] public Camera cameraMain;

        #endregion

        protected virtual void Start()
        {
            InitilizeController();
            hpPotionActivation = KeyCode.Q;
            InitializeTpCamera();
        }

        protected virtual void FixedUpdate()
        {
            charMovement.UpdateMotor();               // updates the ThirdPersonMotor methods
            charMovement.ControlLocomotionType();     // handle the controller locomotion type and movespeed
            charMovement.ControlRotationType();       // handle the controller rotation type
        }

        protected virtual void Update()
        {
            InputHandle();                  // update the input methods
            charMovement.UpdateAnimator();            // updates the Animator Parameters
        }

        public virtual void OnAnimatorMove()
        {
            charMovement.ControlAnimatorRootMotion(); // handle root motion animations 
        }

        #region Basic Locomotion Inputs

        protected virtual void InitilizeController()
        {
            charMovement = GetComponent<MovementCharController>();

            if (charMovement != null)
                charMovement.Init();
        }

        protected virtual void InitializeTpCamera()
        {
            if (tpCamera == null)
            {
                tpCamera = FindObjectOfType<CameraController>();
                if (tpCamera == null)
                    return;
                if (tpCamera)
                {
                    tpCamera.SetMainTarget(this.transform);
                    tpCamera.Init();
                }
            }
        }

        protected virtual void InputHandle()
        {
            MoveInput();
            CameraInput();
            SprintInput();
            //StrafeInput();
            JumpInput();
            AttackInput();
            ActionInput();
            PauseInput();
            IncreaseInput();
        }

        private void IncreaseInput()
        {
            if (!FindObjectOfType<Main>()) return;
            if (!Main.mainGame.charBerserk) return;
            if (Main.gameState == GameStage.Game)
            {
                if (Input.GetKeyDown(hpPotionActivation))
                {
                      Debug.Log("IncreaseInput()2");
                    Main.mainGame.charBerserk.IncreaseParameter(70, PotionType.HpPotion);
                }
                if (Input.GetKeyDown(staminaPotionActivation))
                {
                    Debug.Log("IncreaseInput()3");
                    Main.mainGame.charBerserk.IncreaseParameter(70, PotionType.StaminaPotion);
                }
            }
        }

        private void ActionInput()
        {
            if (!cameraMain.GetComponent<CameraController>().InteractibleObjectSearch()) return;
            if (Input.GetKeyDown(actionInput) && cameraMain.GetComponent<CameraController>().InteractibleObjectSearch().tag == "Key")
            {

                cameraMain.transform.GetComponent<CameraController>().ObjectActvation(); 
            }
        }

        private void PauseInput()
        {
            if (Input.GetKeyDown(pauseInput)&& Main.gameState == GameStage.Game)
            {
                Main.gameState = GameStage.Pause;
                Main.CheckStage();
            }
        }

        public virtual void MoveInput()
        {
            charMovement.input.x = Input.GetAxis(horizontalInput);
            charMovement.input.z = Input.GetAxis(verticallInput);
        }

        protected virtual void CameraInput()
        {
            if (!cameraMain)
            {
                if (!Camera.main) Debug.Log("Missing a Camera with the tag MainCamera, please add one.");
                else
                {
                    cameraMain = Camera.main;
                    charMovement.rotateTarget = cameraMain.transform;
                }
            }

            if (cameraMain)
            {
                charMovement.UpdateMoveDirection(cameraMain.transform);
            }

            if (tpCamera == null)
                return;

            var Y = Input.GetAxis(rotateCameraYInput);
            var X = Input.GetAxis(rotateCameraXInput);

            tpCamera.RotateCamera(X, Y);
        }

        //protected virtual void StrafeInput()
        //{
        //    if (Input.GetKeyDown(strafeInput))
        //        charMovement.Strafe();
        //}

        protected virtual void SprintInput()
        {
            if (Input.GetKeyDown(sprintInput))
                charMovement.Sprint(true);
            else if (Input.GetKeyUp(sprintInput))
                charMovement.Sprint(false);
        }

        protected virtual void AttackInput()
        {
            if (!FindObjectOfType<Main>() && Input.GetKeyDown(attackInput)) FlashLight(); //›ÚÓ ÎË¯ÌËÈ ÌÂÌÛÊÌ˚È ÍÓ‰, ÚÓÎ¸ÍÓ ‰Îˇ ‰Á π3
            // ‡ ˝ÚÓ –¿— ŒÃÃ≈Õ“»–Œ¬¿“‹ 
            //if (Input.GetKeyDown(attackInput))
            //    charMovement.Attack(true);
            //else if (Input.GetKeyUp(attackInput))
            //    charMovement.Attack(false);
        }

        [SerializeField] Light light;
        private void FlashLight()
        {
            if (!light) light = GetComponentInChildren<Light>();
            if (!light) return;
            else
            {
                light.GetComponent<Animation>().enabled = true;
                light.GetComponent<Animation>().Play("Light");
            }
        }

       

        /// <summary>
        /// Conditions to trigger the Jump animation & behavior
        /// </summary>
        /// <returns></returns>
        protected virtual bool JumpConditions()
        {
            return charMovement.isGrounded && charMovement.GroundAngle() < charMovement.slopeLimit && !charMovement.isJumping && !charMovement.stopMove;
        }

        /// <summary>
        /// Input to trigger the Jump 
        /// </summary>
        protected virtual void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput) && JumpConditions())
                charMovement.Jump();
        }

        #endregion       
    }
}
