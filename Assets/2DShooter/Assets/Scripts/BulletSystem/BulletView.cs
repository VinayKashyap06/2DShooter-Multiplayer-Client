using UnityEngine;
using System.Collections;
using Commons;

public class BulletView : MonoBehaviour, IPoolable
{

    public void ResetItem()
    {
        this.gameObject.SetActive(false);
    }
}
