using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class bird : MonoBehaviour
{
    public GameObject cm;
    public GameObject slingshot;

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("vcm");
        slingshot = GameObject.FindGameObjectWithTag("sling");


    }

    private void Update()
    {
        if(slingshot.GetComponent<pullBack>().shot == true)
        {
            slingshot.GetComponent<pullBack>().shot = false;
            StartCoroutine("destroy");
        }
    }

    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(4f);
        cm.GetComponent<CinemachineVirtualCamera>().Follow = slingshot.transform;
        cm.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.1f;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
