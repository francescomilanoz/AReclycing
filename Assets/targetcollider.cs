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

        if(ManomotionManager.Instance.CurrentPoints > 1)
        {
            Vector3 pos1 = new Vector3(9f, -12f, 27f);
            Quaternion rot1 = new Quaternion(0f, 30f, 0f, 0f);
            Vector3 pos2 = new Vector3(0f, -12f, 30f);
            Quaternion rot2 = new Quaternion(0f, 10f, 0f, 0f);
            Vector3 pos3 = new Vector3(-9f, -12f, 30f);
            Quaternion rot3 = new Quaternion(0f, -10f, 0f, 0f);
            Vector3 pos4 = new Vector3(-18f, -12f, 25f);
            Quaternion rot4 = new Quaternion(0f, -30f, 0f, 0f);

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
