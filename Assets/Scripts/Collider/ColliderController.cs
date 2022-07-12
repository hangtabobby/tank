using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class ColliderController : MonoBehaviour
{
    public void Start()
    {
        TextAsset text = Resources.Load<TextAsset>("Data/Player");
        JSONNode json = JSON.Parse(text.text);
        Debug.Log(json.ToString());
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("OnTriggerEnter2D" + collision.gameObject.name);
    // }
    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     Debug.Log("OnCollisionEnter2D" + collision.gameObject.name);
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("OnCollisionEnter2D" + collision.gameObject.name);
    // }
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     //Debug.Log("OnCollisionStay2D" + collision.gameObject.name);
    // }
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     Debug.Log("OnCollisionExit2D" + collision.gameObject.name);
    // }
    // Update is called once per frame
    //void Update()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-1, 0, 0), 5f);
    //    Debug.DrawRay(transform.position, new Vector3(-5, 0, 0), Color.yellow);
    //    if (hit.transform != null)
    //    {
    //        Debug.Log(hit.transform.gameObject.name);
    //    }
    //}
}
