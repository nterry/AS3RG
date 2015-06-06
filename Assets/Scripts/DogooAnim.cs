using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DogooAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(1.5f, 1));
        mySequence.Join(transform.DOScaleY(0.15f, 1));
        mySequence.SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {
	   
	}
}
