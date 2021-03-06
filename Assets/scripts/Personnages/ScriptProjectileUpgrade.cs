using UnityEngine;
using System.Collections;

public class ScriptProjectileUpgrade : MonoBehaviour {

	public float pointsDommageUp;
	private AudioSource audioSource_destruction;
	private Transform _perso;
	AudioClip son_destruction;
	private personnage persoScript;

	void Start(){
		// crée une source audio et recuper le son à jouer
		audioSource_destruction = gameObject.AddComponent<AudioSource> () as AudioSource;
		AudioClip son_destruction = Resources.Load ("sons/recoitprojectile") as AudioClip;
		audioSource_destruction.clip = son_destruction;
		audioSource_destruction.playOnAwake = false;

		//va chercher le personnage actif;
		Transform persos = GameObject.Find ("Persos").transform;
		foreach (Transform child in persos) {
			if (child.gameObject.activeSelf == true) {
				_perso = child;
			}
		}
		//recuper le script du personnage
		persoScript =_perso.GetComponent<personnage> () as personnage;
		pointsDommageUp= persoScript.domagePerso;
	}

	void OnCollisionEnter2D (Collision2D coll){
		
		audioSource_destruction.Play ();
		this.transform.localScale = new Vector3 (0,0,0); 
		GameObject.Destroy (this.gameObject, 1);
		Rigidbody2D rbTouche = coll.gameObject.GetComponent <Rigidbody2D>();

		if (coll.gameObject.transform.parent) {
			if ((coll.gameObject.transform.parent.name == "mesEnnemis")||(coll.gameObject.layer== 13)) {
				rbTouche.SendMessageUpwards ("Toucher", pointsDommageUp, SendMessageOptions.RequireReceiver);
			}

		}
	}

}
