using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public CheckPoint nextCheckpoint = null;
    public bool IsShown;
    void OnTriggerEnter2D(Collider2D collider)
    {
        var stats = collider.GetComponent<PlayerStats>();
        if (stats != null)
        {
            if (nextCheckpoint != null)
            {
                nextCheckpoint.Show();
            }
            Hide();
            stats.checkPoint=gameObject.gameObject.GetComponent<Transform>().position;
        }
    }
	private void Start()
	{
        if(nextCheckpoint is not null && !nextCheckpoint.IsShown)nextCheckpoint.Hide();
	}
	void Hide()
    {
        IsShown=false;
        gameObject.SetActive(false);
    }
    void Show()
    {
        IsShown = true;
        gameObject.SetActive(true);
    }
}
