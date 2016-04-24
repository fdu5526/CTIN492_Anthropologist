using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Physics2DBody {

	public bool isIndoors;

	// player movement variables
	float baseSpeed;																// how fast player moves
	public float playerSpeed;												// equal to baseSpeed or dashSpeed

	// footsteps variables
	Timer footstepTimer;														// last time we took a footstep
	Timer footstepSoundTimer;
	Footsteps footsteps;														// footsteps following the player

	// other gameobjects that this affects
	GameObject playerAnimation;											// animation of the player
	GameObject playerShadow;												// shadow of the player
	GameObject mainCamera;													// for enabling motion blur
	private AudioSource[] audios;										// all audios

	// animation
	enum AnimationState { Idle, Run, SpinClockwise, SpinCounterclockwise, Dash };
	Animator animator;															// animations of the player animation
	Animator shadowAnimator;												// animations of the player shadow

	// player input
	public Vector2 lv;


	AudioClip[] indoorFootstepSounds, outdoorFootstepSounds;


	// Use this for initialization
	protected override void Awake () {
		base.Awake();

		baseSpeed = 24.0f;


		playerSpeed = baseSpeed;

		footstepTimer = new Timer(0.5f);
		footstepSoundTimer = new Timer(0.5f);
		footsteps = new Footsteps(30, Resources.Load<Sprite>("Sprites/Player/footstepRight"));

		lv = Vector2.zero;


		playerAnimation = transform.Find("PlayerAnimation").gameObject;
		animator = playerAnimation.GetComponent<Animator>();
		playerShadow = transform.Find("PlayerShadow").gameObject;
		shadowAnimator = playerShadow.GetComponent<Animator>();
		audios = GetComponents<AudioSource>();
		mainCamera = GameObject.Find("Main Camera");


		indoorFootstepSounds = new AudioClip[3];
		indoorFootstepSounds[0] = Resources.Load<AudioClip>("Sounds/Player/footstep_floor1");
		indoorFootstepSounds[1] = Resources.Load<AudioClip>("Sounds/Player/footstep_floor2");
		indoorFootstepSounds[2] = Resources.Load<AudioClip>("Sounds/Player/footstep_floor3");
		outdoorFootstepSounds = new AudioClip[3];
		outdoorFootstepSounds[0] = Resources.Load<AudioClip>("Sounds/Player/footstep_land1");
		outdoorFootstepSounds[1] = Resources.Load<AudioClip>("Sounds/Player/footstep_land2");
		outdoorFootstepSounds[2] = Resources.Load<AudioClip>("Sounds/Player/footstep_land3");
	}

	// wrapper for working with animator state machine for both sprite and shadow
	void SetAnimatorMovementState (int value) {
		animator.SetInteger("movementState", value);
		shadowAnimator.SetInteger("movementState", value);
	}

	// player velocity
	void CalculateCharPosition (Vector2 lv) {
		
		rigidbody2d.velocity = lv * playerSpeed;

		// do animation and audio
		if (rigidbody2d.velocity.sqrMagnitude > 0.2f) {
			SetAnimatorMovementState((int)AnimationState.Run);
		} else {
			SetAnimatorMovementState((int)AnimationState.Idle);
		}

		// take another step
		if (lv.sqrMagnitude > 0.01f) {
			if (!isIndoors && footstepTimer.IsOffCooldown) {
				footsteps.NextStep(transform.position, lv);
				footstepTimer.Reset();
			}

			if (footstepSoundTimer.IsOffCooldown) {
				if (isIndoors) {
				audios[0].clip = indoorFootstepSounds[(int)UnityEngine.Random.Range(0f, indoorFootstepSounds.Length)];
				} else {
					audios[0].clip = outdoorFootstepSounds[(int)UnityEngine.Random.Range(0f, outdoorFootstepSounds.Length)];
				}

				audios[0].Play();
				footstepSoundTimer.Reset();
			}
			
		}
	}


	protected void FaceDirection (Vector2 d) {
		float origZ = rigidbody2d.rotation;
		float targetZ = Global.Angle(Vector2.down, d);
  	rigidbody2d.rotation = Mathf.LerpAngle(origZ, targetZ, 0.3f);
	}



  // fixed calculations with rigidbodies
  void FixedUpdate () {

		// calculate player values
		CalculateCharPosition(lv);
		if (lv.sqrMagnitude > 0.1f) {
			FaceDirection(lv);
		}
  }
	
	// Update is called once per frame, for collecting user input
	void Update () {

		float lx, ly;
		lx = ly = 0f;
		
		
		// left X
		if (Input.GetKey("a")) { lx = -1f; } 
		else if (Input.GetKey("d")) { lx = 1f; } 
		else { lx = 0f; }

		// left Y
		if (Input.GetKey("s")) { ly = -1f; } 
		else if (Input.GetKey("w")) { ly = 1f; } 
		else { ly = 0f; }
		

		// player input vectors
		lv.Set(lx, ly);
	}
}
