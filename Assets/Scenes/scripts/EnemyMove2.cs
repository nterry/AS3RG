
using UnityEngine;
using System.Collections;

public class EnemyMove2 : MonoBehaviour {
	
	
	Transform target;
	
	float minTarX = 1;
	float maxTarX = 10;
	float minTarZ = 1;
	float maxTarZ = 10;
	float tarX;
	float tarZ;
	float dampX;
	float dampZ;
	float timeSwitch = 100;
	
	
	bool  death = false;
	
	void  Start (){
		CreateTarPoint();
	}
	
	void  Update (){
		if(target != null){
			transform.GetComponent<NavMeshAgent>().destination = target.position;
		}else{
			if(timeSwitch <= 0){
				timeSwitch = 100;
				CreateTarPoint();
			}else{
			
				transform.GetComponent<NavMeshAgent>().destination = new Vector3(tarX, 0, tarZ);
				timeSwitch -= 1 * Time.deltaTime;
			}
		}	
		
		if(death){
			//GUITextHandler.score += 100;
			Destroy(gameObject);
		}
	}
	
	void  CreateTarPoint (){
		dampX = Random.Range(1.0f, 3.0f);
		dampZ = Random.Range(1.0f, 3.0f);
		
		tarX = Random.Range(minTarX, maxTarX) - dampX;
		tarZ = Random.Range(minTarZ, maxTarZ) - dampZ;
	}
	
	
	void  OnTriggerEnter ( Collider col  ){
		if(col.gameObject.tag == "Bullet"){
			death = true;
		}
		
		if(col.gameObject.tag == "Player"){
			target = col.transform;
		}
	}	


	void  OnTriggerExit ( Collider col  ){
		if(col.gameObject.tag == "Player"){
			target = null;
		}
	}
}
