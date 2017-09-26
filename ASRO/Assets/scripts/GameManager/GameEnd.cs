using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour {



	public static void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}
	public static void GameWin(){
		SceneManager.LoadScene ("GameWin");
	}
}
