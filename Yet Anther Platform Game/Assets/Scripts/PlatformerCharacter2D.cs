using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        public bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private bool immortal= false;
		private bool win=false;
		public float timeLeft=2;
		public Text winText ;
        public float immortalTimeCounter=3;
        private float temp;
        public float finishTimeCounter=5;
		public int m_Lifes=1;
		public Vector3 startPosition = new Vector3(0,0,0);
		private int dieCounter;
		private bool secretFound= false;
		private int level = 1;
        public GameObject tombstone;
//		AudioSource source;
		AudioClip clip;
        private void Awake()
        { temp = immortalTimeCounter;
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
//			source = GetComponent<AudioSource> ();
            Debug.Log(PlayerPrefs.GetInt("Progress"));
        }
		public void StartFromCheckpoint(){
			m_Lifes = 1;
			//SceneManager.LoadScene (0);
			m_Rigidbody2D.velocity =Vector3.zero;
			m_Rigidbody2D.angularVelocity = 0f; 

			transform.position = startPosition;
		}

		private void Update(){

            TimeCounterWhenCollisionWithFlag();
            TimeCounterForImmortality();

        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
			if (m_Lifes <= 0) {
				dieCounter++;
                Debug.Log(dieCounter);
				Instantiate (tombstone, transform.position, Quaternion.identity);
				StartFromCheckpoint ();

			}
	//			StartCoroutine("wait");


        }

        public void Move(float move, bool crouch, bool jump)
        {
			
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }
	
            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
		//IEnumerator wait()
		//{
		//	if (immortal == true) {
		//		yield return new WaitForSeconds (1f);

		//		immortal = false;
			
		//}
		//	if (win == true) {

  //              dieCounter = 0;
		//		yield return new WaitForSeconds (5f);
		//		winText.text = "";
		//		win = false;
		//		if (level==1)
		//		SceneManager.LoadScene ("level 2");
		//		level++;

				
		//	}


		//}
		private void OnCollisionEnter2D( Collision2D other){
			if (other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Rock2"))
				m_Lifes--;
		}
		private void OnTriggerEnter2D(Collider2D other){
			if (immortal == false) {
				immortal = true;

				if (other.gameObject.CompareTag ("Enemy")) {
					m_Lifes--;
				}
			}
			if (other.gameObject.CompareTag ("Secret")) {
				secretFound=true;
				other.gameObject.SetActive (false);
				Debug.Log ("weszło");
			}
			if (other.gameObject.CompareTag("CheckPoint"))

				{
					startPosition = other.transform.position;
				other.gameObject.SetActive (false);
				}
		
            if (other.gameObject.CompareTag("Finish"))
            {
                LevelCompleted();
        
            }
            if (other.gameObject.CompareTag("KillZone"))

            {
                StartFromCheckpoint();
            }
        }

        private void LevelCompleted()
        {
            winText.text = "YOU WIN !!! Die counter: " + dieCounter;
            if (secretFound == true)
                winText.text = "YOU WIN !!!You also found a secret! nice ! Die counter: " + dieCounter;
            winText.text += " We are moving you to next level...";
            win = true;
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
	
       private void TimeCounterWhenCollisionWithFlag()
        {
            if (win == true)
            {
                finishTimeCounter -= Time.deltaTime;

            }
            if (finishTimeCounter<0)
            {

                MoveToNextLevel();
            }

        }

        private void MoveToNextLevel()
        {
                dieCounter = 0;
            winText.text = "";
            if (PlayerPrefs.GetInt("Progress") == 1)
            {
                PlayerPrefs.SetInt("Progress", 2);
                SceneManager.LoadScene("level 2");

            }
            if (PlayerPrefs.GetInt("Progress") == 2)
            {

                winText.text = "But there is no next level :( Thank you for playing this game! I'm doing my best to improve that game and add more content so be patient and wait for it !";

            }
        }
        private void TimeCounterForImmortality()
        { 
            if (immortal == true)
            {
                immortalTimeCounter -= Time.deltaTime;

            }
            if (immortalTimeCounter < 0)
            {
                immortal = false;
                immortalTimeCounter = temp;
               
            }

        }
    }

   
    }

