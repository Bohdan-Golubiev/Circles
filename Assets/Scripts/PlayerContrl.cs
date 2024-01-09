using UnityEngine;
using UnityEngine.UI;

public class PlayerContrl : MonoBehaviour
{
    public float moveForce = 100f; // force of move
    private Rigidbody2D rb;
    public int countStage = 1;
    public GameObject[] objects;
    private DinamicArea dynamicArea;

    public float[,] pointsTrigger = new float[4, 2] { { -0.47f, -1.72f }, { 8.34f, -4.35f }, { -0.51f, -7.7f }, {0f, -11.46f } };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dynamicArea = GameObject.FindGameObjectWithTag("Area").GetComponent<DinamicArea>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horizontalInput, 0) * 2 * moveForce * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            if(countStage<5)
            {
                dynamicArea.ChangeSize(new Vector2(5f, 5f));
                Boost();
            }
            else
            {
                Destroy(collision.gameObject);
            }
            switch (countStage)
            {
                case 1:
                    MoveTrigger(collision.transform, countStage-1);
                    GameObject spawnedObject = Instantiate(objects[1], new Vector2(-3.55f, -2.75f), Quaternion.Euler(new Vector3(0f, 0f, 15f)));
                    spawnedObject.transform.localScale = new Vector3(3f, 0.1f, 1f);
                    GameObject spawnedObject1 = Instantiate(objects[1], new Vector2(-1.12f, -2.36f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    spawnedObject1.transform.localScale = new Vector3(2f, 0.1f, 1f);
                    break;
                case 2:
                    MoveTrigger(collision.transform, countStage-1);
                    GameObject spawnedObject3 = Instantiate(objects[0], new Vector2(-1.83f, -2.84f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject4 = Instantiate(objects[0], new Vector2(-1.03f, -2.84f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject5 = Instantiate(objects[0], new Vector2(-0.23f, -2.84f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject6 = Instantiate(objects[0], new Vector2(-1.83f, -3.64f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject7 = Instantiate(objects[0], new Vector2(-1.03f, -3.64f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject8 = Instantiate(objects[0], new Vector2(-0.23f, -3.64f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    break;
                case 3:
                    MoveTrigger(collision.transform, countStage - 1);
                    GameObject spawnedObject9 = Instantiate(objects[1], new Vector2(-0.24f, -8.23f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    spawnedObject9.transform.localScale = new Vector3(2f, 0.15f, 1f);
                    GameObject spawnedObject10 = Instantiate(objects[2], new Vector2(3.25f, -9.1f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject11 = Instantiate(objects[2], new Vector2(2.62f, -9f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject12 = Instantiate(objects[2], new Vector2(2.04f, -8.87f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject13 = Instantiate(objects[2], new Vector2(1.49f, -8.66f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject14 = Instantiate(objects[2], new Vector2(0.95f, -8.44f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    GameObject spawnedObject15 = Instantiate(objects[1], new Vector2(5.39f, -9.55f), Quaternion.Euler(new Vector3(0f, 0f, -15f)));
                    spawnedObject15.transform.localScale = new Vector3(4f, 0.15f, 1f);
                    break;
                case 4:
                    MoveTrigger(collision.transform, countStage - 1);
                    GameObject spawnedObject16 = Instantiate(objects[1], new Vector2(-5.09f, -7.82f), Quaternion.Euler(new Vector3(0f, 0f, 90f)));
                    spawnedObject16.transform.localScale = new Vector3(2f, 0.15f, 1f);
                    GameObject spawnedObject17 = Instantiate(objects[1], new Vector2(-3.55f, -9.58f), Quaternion.Euler(new Vector3(0f, 0f, -28f)));
                    spawnedObject17.transform.localScale = new Vector3(3.5f, 0.15f, 1f);
                    GameObject spawnedObject18 = Instantiate(objects[1], new Vector2(-0.56f, -10.38f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    spawnedObject18.transform.localScale = new Vector3(3f, 0.15f, 1f);
                    GameObject spawnedObject19 = Instantiate(objects[1], new Vector2(-1.04f, -12.08f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    spawnedObject19.transform.localScale = new Vector3(3f, 0.15f, 1f);
                    GameObject spawnedObject20 = Instantiate(objects[1], new Vector2(-4.17f, -12.3f), Quaternion.Euler(new Vector3(0f, 0f, 7.88f)));
                    spawnedObject20.transform.localScale = new Vector3(3.5f, 0.15f, 1f);
                    break;
            }
            countStage++;
            
        }
        if (countStage == 6)
        {
            UIManager.Instance.ShowVictoryMessage();
        }
    }
    private void Boost()
    {
        moveForce += 5f;
    }
    private void MoveTrigger(Transform triggerTransform,int stage)
    {
        triggerTransform.position = new Vector3(pointsTrigger[stage, 0], pointsTrigger[stage,1], 0);
    }
}

