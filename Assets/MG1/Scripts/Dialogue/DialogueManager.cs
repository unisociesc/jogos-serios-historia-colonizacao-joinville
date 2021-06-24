using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Text buttonText;
    public GameObject uiObject;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Começou o dialogo!");
        Time.timeScale = 0;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            Destroy(GameObject.FindWithTag("TargetArea"));
            EndDialogue();
            Time.timeScale = 1;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        if(sentences.Count == 0) {
            buttonText.text = "Fechar";
        }
    }

    void EndDialogue() {
        Debug.Log("acabou aqui...");
        uiObject.SetActive(false);
    }
}
