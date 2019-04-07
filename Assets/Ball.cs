using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isPressed = false;
    public float releaseTime = 0.12f;
    public float maxDragDistance = 4.0f;
    public Rigidbody2D Anchor;

    public GameObject nextball;

    void Update()
    {
        if (isPressed)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(MousePos, Anchor.position) > maxDragDistance)
            {
                rb.position = Anchor.position + (MousePos - Anchor.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = MousePos;
            }

        }
    }


    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;

    }

    // Update is called once per frame
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());

    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(3f);
        if(nextball != null) nextball.SetActive(true);
        else
        {
            Debug.Log("Przegranko xD Lamus");
            EnemyDed.EnemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
