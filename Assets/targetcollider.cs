using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetcollider : MonoBehaviour
{
    float speed = 1f;
    float delta = 3f;
    public int decider=1;
    public int health;
    public bool flag;
    public float initialpos;
    public AudioSource hitsound;
    public AudioSource hit_good;
    public AudioSource hit_bad;

    public Vector3 pos1;
    public Quaternion rot1;
    public Vector3 pos2;
    public Quaternion rot2;
    public Vector3 pos3;
    public Quaternion rot3;
    public Vector3 pos4;
    public Quaternion rot4;

    public Vector3 originalScale;
    public Vector3 smallestScale;

    public AudioSource[] sounds;

    public GameObject explosiontime;
    public IEnumerator destroy(GameObject missile)
    {
        yield return new WaitForSeconds(3f);
        Destroy(missile);
    }
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();

        pos1 = GameObject.Find("Plastic Bin").transform.position;
        rot1 = GameObject.Find("Plastic Bin").transform.rotation;
        pos2 = GameObject.Find("Ewaste Bin").transform.position;
        rot2 = GameObject.Find("Ewaste Bin").transform.rotation;
        pos3 = GameObject.Find("Paper Bin").transform.position;
        rot3 = GameObject.Find("Paper Bin").transform.rotation;
        pos4 = GameObject.Find("Organic Bin").transform.position;
        rot4 = GameObject.Find("Organic Bin").transform.rotation;

        originalScale = GameObject.Find("Plastic Bin").transform.localScale;
        smallestScale = originalScale;
        smallestScale.x = smallestScale.x * 0.7f;
        smallestScale.y = smallestScale.y * 0.7f;
        smallestScale.z = smallestScale.z * 0.7f;

        initialpos = transform.position.x;
    }


    void Shuffle(int[] a)
    {
        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            int temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }

    }
        void OnCollisionEnter(Collision collision)
    {

        Destroy(collision.collider.gameObject);

        if (gameObject.tag == "ORGANIC_BIN" && collision.collider.tag == "ORGANIC")
        {
            ManomotionManager.Instance.SetCurrentPoints(ManomotionManager.Instance.CurrentPoints + 1);
            GameUIcontroller loadData = GameObject.Find("Spookey Canvas").GetComponent<GameUIcontroller>();
            if(loadData.isAudioActive)
            {
                sounds[0].Play();
            }

            if(loadData.isVibrationActive)
            {
                AndroidManager.HapticFeedback();
            }
         
        }
        else if (gameObject.tag == "PLASTIC_BIN" && collision.collider.tag == "PLASTIC")
        {
            ManomotionManager.Instance.SetCurrentPoints(ManomotionManager.Instance.CurrentPoints + 1);
            GameUIcontroller loadData = GameObject.Find("Spookey Canvas").GetComponent<GameUIcontroller>();
            if (loadData.isAudioActive)
            {
                sounds[0].Play();
            }

            if (loadData.isVibrationActive)
            {
                AndroidManager.HapticFeedback();
            }

        }
        else if (gameObject.tag == "PAPER_BIN" && collision.collider.tag == "PAPER")
        {
            ManomotionManager.Instance.SetCurrentPoints(ManomotionManager.Instance.CurrentPoints + 1);
            GameUIcontroller loadData = GameObject.Find("Spookey Canvas").GetComponent<GameUIcontroller>();
            if (loadData.isAudioActive)
            {
                sounds[0].Play();
            }

            if (loadData.isVibrationActive)
            {
                AndroidManager.HapticFeedback();
            }
        }
        else if (gameObject.tag == "EWASTE_BIN" && collision.collider.tag == "EWASTE")
        {
            ManomotionManager.Instance.SetCurrentPoints(ManomotionManager.Instance.CurrentPoints + 1);
            GameUIcontroller loadData = GameObject.Find("Spookey Canvas").GetComponent<GameUIcontroller>();
            if (loadData.isAudioActive)
            {
                sounds[0].Play();
            }

            if (loadData.isVibrationActive)
            {
                AndroidManager.HapticFeedback();
            }
        }
        else
        {
            if (ManomotionManager.Instance.CurrentPoints > 0)
            {
                ManomotionManager.Instance.SetCurrentPoints(ManomotionManager.Instance.CurrentPoints - 1);
            } 
             
            GameUIcontroller loadData = GameObject.Find("Spookey Canvas").GetComponent<GameUIcontroller>();
            if (loadData.isAudioActive)
            {
                sounds[1].Play();
            }

            if (loadData.isVibrationActive)
            {
                StartCoroutine(VibrationWrong());
            }
           

        }

        if(ManomotionManager.Instance.CurrentPoints > 8)
        {


            Vector3[] positions = { pos1, pos2, pos3, pos4 };
            Quaternion[] rotations = { rot1, rot2, rot3, rot4 };

            int[] rand_positions = { 0, 1, 2, 3 };
            Shuffle(rand_positions);

            GameObject.Find("Plastic Bin").transform.position = positions[rand_positions[0]];
            GameObject.Find("Ewaste Bin").transform.position = positions[rand_positions[1]];
            GameObject.Find("Organic Bin").transform.position = positions[rand_positions[2]];
            GameObject.Find("Paper Bin").transform.position = positions[rand_positions[3]];

            GameObject.Find("Plastic Bin").transform.rotation = rotations[rand_positions[0]];
            GameObject.Find("Ewaste Bin").transform.rotation = rotations[rand_positions[1]];
            GameObject.Find("Organic Bin").transform.rotation = rotations[rand_positions[2]];
            GameObject.Find("Paper Bin").transform.rotation = rotations[rand_positions[3]];
        }

        if(ManomotionManager.Instance.CurrentPoints > 16)
        {
            GameObject.Find("Plastic Bin").transform.localScale = smallestScale;
            GameObject.Find("Ewaste Bin").transform.localScale = smallestScale;
            GameObject.Find("Organic Bin").transform.localScale = smallestScale;
            GameObject.Find("Paper Bin").transform.localScale = smallestScale;
        } else
        {
            GameObject.Find("Plastic Bin").transform.localScale = originalScale;
            GameObject.Find("Ewaste Bin").transform.localScale = originalScale;
            GameObject.Find("Organic Bin").transform.localScale = originalScale;
            GameObject.Find("Paper Bin").transform.localScale = originalScale;
        }


        //hitsound.Play();
        if(collision.collider.tag=="tip")
        {
            print("collide");
            //  collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //     child.transform.SetParent(newParent);
      //      collision.collider.gameObject.transform.parent = this.gameObject.transform;
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.collider.gameObject.transform.parent = this.transform;
            //     collision.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            health = health - 1;

        }
        if (collision.collider.tag == "rocket")
        {
            print("rocket");
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //collision.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            collision.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(destroy(collision.collider.gameObject));
          
            health = health - 3;
        }
        if(health<=0)
        {
            //collision.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();

        }


  


    }

    IEnumerator VibrationWrong()
    {
        AndroidManager.HapticFeedback();
        yield return new WaitForSeconds(0.2f);
        AndroidManager.HapticFeedback();
        yield return new WaitForSeconds(0.2f);
        AndroidManager.HapticFeedback();

    }


    // Update is called once per frame
    void Update()
    {
        

        if (flag)
        {
            transform.LookAt(Camera.main.transform);

            if (health > 0)
            {
                float y = Mathf.PingPong(speed * Time.time, delta);
                // decider = decider * -1; 
                Vector3 pos = new Vector3(initialpos + Mathf.Sin(Time.time * 1f) * decider * y, y, transform.position.z);
                transform.position = pos;
            }
            else
            {
                var go = Instantiate(explosiontime, this.transform);
                go.SetActive(true);
                go.transform.parent = GameObject.FindGameObjectWithTag("Ball").transform;
                Destroy(this.gameObject);
            }
        }
    }
}
