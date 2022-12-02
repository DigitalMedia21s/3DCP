using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject Panel;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            OpenPanel();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            DoorOpen();
        }
    }

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void DoorOpen()
    {
        Debug.Log(parent.name);
        Animator animator = parent.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            //Debug.Log("test");
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            parent = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("this´Â" + this.name);

            if (this.gameObject.name.Contains("door0coli"))
            {
                parent = transform.parent.gameObject;

                //Debug.Log("parent´Â" + parent.name);
            }
            if (this.gameObject.name.Contains("door1coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door2coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door3coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door4coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door5coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door6coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door7coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door8coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door9coli"))
            {
                parent = transform.parent.gameObject;

            }
            if (this.gameObject.name.Contains("door10coli"))
            {
                parent = transform.parent.gameObject;

            }
        }
    }
}
