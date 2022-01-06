using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopulation : MonoBehaviour
{
    public Sprite Banana;
	public Sprite Paper;
	public Sprite Bottle;
	public Sprite Apple;
	public Sprite Kiwi;
	public Sprite Lime;
	public Sprite Ball;
	public Sprite PaperBag;
	public Sprite Foglio;
	public Sprite Glass;
	public Sprite Water;
	public Sprite Basket;
	public Sprite Lid;
	public Sprite Container;
	public Sprite Aroma;
	public Sprite Spanner;
	public Sprite Pallet;
	public Sprite Carpet;

	public Text text;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		text = GameObject.Find("Object").GetComponent<Text>();
		if (text.text.Contains("Banana"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Banana;
		}
		if (text.text.Contains("Kiwi"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Kiwi;
		}
		if (text.text.Contains("Lime"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Lime;
		}
		if (text.text.Contains("Apple"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Apple;
		}
		if (text.text.Contains("ottle"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Bottle;
		}
		if (text.text.Contains("Paper"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Paper;
		}
		if (text.text.Contains("ball"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Ball;
		}
		if (text.text.Contains("bag"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = PaperBag;
		}
		if (text.text.Contains("Sheet"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Paper;
		}
		if (text.text.Contains("cup"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Glass;
		}
		if (text.text.Contains("Basket"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Basket;
		}
		if (text.text.Contains("Lid"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Lid;
		}
		if (text.text.Contains("Container"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Container;
		}
		if (text.text.Contains("Aroma"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Aroma;
		}
		if (text.text.Contains("Spanner"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Spanner;
		}
		if (text.text.Contains("Pallet"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Pallet;
		}
		if (text.text.Contains("Carpet"))
		{
			GameObject.Find("Image").GetComponent<Canvas>().enabled = true;
			gameObject.GetComponent<Image>().sprite = Carpet;
		}
	}
}
