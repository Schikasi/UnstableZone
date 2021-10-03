using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, ITyleType
{
    // Start is called before the first frame update
    public List<GameObject> _sprites;

    public Sprite get_random()
    {
        Sprite _return = null;
        System.Random rand = new System.Random();
        _return = _sprites[rand.Next(0, _sprites.Count)].GetComponent<SpriteRenderer>().sprite;
        return _return;
    }
}
