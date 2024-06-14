using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int hearts=3;
    public int maxhearts=>heartImages.Length;
    public Sprite EnableHeart;
    public Sprite DisableHeart;
    public Image[] heartImages;
    public Vector3 checkPoint;
	private void Start()
	{
		checkPoint=transform.position;
	}
	void Update()
    {
        for(int i = 0; i < maxhearts; i++)
        {
            if (i < hearts) heartImages[i].sprite=EnableHeart;
            else heartImages[i].sprite=DisableHeart;
        }
        if(transform.position.y < -10)
        {
            DoDamage(maxhearts);
        }
    }
    public void DoDamage(int damage)
    {
        if(damage<hearts)hearts-=damage;
        else
        {
            hearts = maxhearts;
            transform.position=checkPoint;
        }
    }
    public void Heal(int hp)
    {
        hearts += hp;
    }
}
