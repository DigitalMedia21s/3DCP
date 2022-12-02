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
        Animator animator = parent.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            Debug.Log("test");
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            parent = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("this´Â" + this.name);

            if (this.gameObject.name.Contains("RightColi"))
            {
                parent = transform.parent.gameObject;

                //Debug.Log("parent´Â" + parent.name);
            }
            if (this.gameObject.name.Contains("LeftColi"))
            {
                parent = transform.parent.gameObject;

            }
        }
    }
}
