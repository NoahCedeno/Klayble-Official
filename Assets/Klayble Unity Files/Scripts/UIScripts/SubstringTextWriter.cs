using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SubstringTextWriter : MonoBehaviour
{
    [SerializeField]
    private string m_TextToWrite;

    public string TextToWrite { get => m_TextToWrite; set => m_TextToWrite = value; }

    [SerializeField]
    [Range(0.01f, 0.1f)] // Can I stack these fellas? There's no errors so...
    private float m_TextSpeed = 0.05f;

    public float TextSpeed { get => m_TextSpeed; set => m_TextSpeed = value; }

    private Text TextBox;

    /// <summary>
    /// Simply initializes the TextBox within the same GameObject!
    /// </summary>
    private void Awake()
    {
        TextBox = gameObject.GetComponent<Text>();
        StartCoroutine(Write());
    }

    /// <summary>
    /// Writes a message in a certain Text element via substrings, like in Animal Crossing and
    /// most RPGs. I should develope a little sound to play with this for more aesthetic!
    /// </summary>
    /// <returns>An IEnumerator to make this bad boy a Coroutine :)</returns>
    public IEnumerator Write()
    {
        for (int i = 0; i < TextToWrite.Length + 1; i++)
        {
            TextBox.text = TextToWrite.Substring(0, i);
            yield return new WaitForSecondsRealtime(TextSpeed);
            // TODO: Maybe Play a Sound here
        }
    }
}