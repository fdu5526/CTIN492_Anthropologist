using UnityEngine;
/* 
 * trail of footsteps following main character
 * uses a set number of steps to increase efficiency
 */
public class Footsteps {
	GameObject[] steps;
	int currentIndex;
	const float stepR = 0.5f;
	const float width = 0.3f;

	public Footsteps(int n, Sprite s) {
		currentIndex = 0;
		steps = new GameObject[n];
		for (int i = 0; i < steps.Length; i++) {
			GameObject g = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/General/Footstep"));
			if (s != null) {
				g.GetComponent<SpriteRenderer>().sprite = s;
			}
			steps[i] = g;
			steps[i].GetComponent<Transform>().position = Vector2.up * i;
			steps[i].GetComponent<FootstepParticle>().transparency = 0f;
			if (i % 2 == 0) {
				steps[i].GetComponent<Transform>().localScale = new Vector2(-2f, 2f);
			}
			
		}
	}


	public void DestroyFootsteps () {
		for (int i = 0; i < steps.Length; i++) {
			MonoBehaviour.Destroy(steps[i]);
		}
	}

	public void NextStep(Vector2 playerPosition, Vector2 direction) {
		
		// people don't shuffle steps in the same spot
		if (direction.sqrMagnitude < 0.001f) {
			return;
		}

		float theta;
		GameObject st = steps[currentIndex];

		// left foot or right foot + a bit random shuffling
		Vector2 p = new Vector2(direction.y, -direction.x) * width;
		Vector2 v = Random.insideUnitCircle * stepR;
		Vector3 v3;

		if (currentIndex % 2 == 0) {
			v3 = (Vector3)(playerPosition + p + v);
			v3.z = 2.69f;
			st.GetComponent<Transform>().position = v3;
		} else {
			v3 = (Vector3)(playerPosition - p + v);
			v3.z = 2.69f;
			st.GetComponent<Transform>().position = v3;
		}
		
		st.GetComponent<FootstepParticle>().transparency = 1f;

		// which direction the footstep faces
		theta = Global.Angle(Vector2.down, direction);
    st.GetComponent<Transform>().localEulerAngles = new Vector3(0f, 0f, theta);

    // looping index
		currentIndex++;
		currentIndex = currentIndex >= steps.Length ? 0 : currentIndex;

	}
}