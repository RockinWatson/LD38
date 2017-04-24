using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float _health = 50.0f;

	public void Damage(float amount) {
		_health -= amount;
		if(_health <= 0.0f) {
			Die();
		}
	}

    public void PlayerDeathAudio()
    {
        var playerDeath = GameObject.Find("AudioController");
        playerDeath.GetComponent<AudioController>().playerDeathAudio();
    }

    private void Die() {
		FXManager.Get().SpawnKablooey(this.transform.position);
        PlayerDeathAudio();
		Destroy(this.gameObject);
	}
}
