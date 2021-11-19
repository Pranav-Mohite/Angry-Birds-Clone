using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class pullBack : MonoBehaviour
{
    public GameObject[] pigs;
    public GameObject scoreBoard;

    public CinemachineVirtualCamera cm;

    public LineRenderer lr1, lr2;
    public Transform point1, point2;
    public Transform idlePos;

    public Vector3 currentPos;

    public GameObject birdPrefab;
    Rigidbody2D bird;
    Collider2D birdCol;

    public float maxLength;
    public float birdPositionOffset;
    public float force;

    public bool shot;

    void Start()
    {
        Time.timeScale = 1f;

        lr1.positionCount = 2;
        lr2.positionCount = 2;

        lr1.SetPosition(0, point1.position);
        lr2.SetPosition(0, point2.position);

        lr1.SetPosition(1, idlePos.position);
        lr2.SetPosition(1, idlePos.position);

        CreateBird();
    }

    // Update is called once per frame
    void Update()
    {
        pigs = GameObject.FindGameObjectsWithTag("pig");

        if(pigs.Length == 0)
        {
            StartCoroutine("displayScore");
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            currentPos = Camera.main.ScreenToWorldPoint(mousePos);

            currentPos = idlePos.position + Vector3.ClampMagnitude(currentPos - idlePos.position, maxLength);

            lr1.SetPosition(1, currentPos);
            lr2.SetPosition(1, currentPos);

            if (bird)
            {
                Vector3 dir = currentPos - idlePos.position;
                bird.transform.position = currentPos + dir.normalized * birdPositionOffset;
                bird.transform.right = -dir.normalized;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            lr1.SetPosition(1, idlePos.position);
            lr2.SetPosition(1, idlePos.position);

            Shoot();
        }
    }

    public void CreateBird()
    {
        //Instantiate(birdPrefab, idlePos.position, Quaternion.identity);

        bird = Instantiate(birdPrefab, idlePos.position, idlePos.rotation).GetComponent<Rigidbody2D>();
        birdCol = bird.GetComponent<Collider2D>();
        birdCol.enabled = false;

        bird.isKinematic = true;
    }

    public void Shoot()
    {
        //bird.GetComponent<bird>().destroy();
        shot = true;
        cm.Follow = bird.transform;
        cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;

        bird.isKinematic = false;
        Vector3 birdForce = (currentPos - idlePos.position) * force * -1;
        bird.velocity = birdForce;
        birdCol.enabled = true;
        bird.freezeRotation = false;
        //bird.GetComponent<Bird>().Release();

        bird = null;
        //birdCol = null;
        Invoke("CreateBird", 2);
    }

    public IEnumerator displayScore()
    {
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0f;
        scoreBoard.SetActive(true);
    }
}
