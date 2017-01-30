using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exclamationBlock : MonoBehaviour {

    //-----------------------------------------------------------------
    // ブロックを叩いたら、ブロックが消滅する関数。
    // ----------------------------------------------------------------
    public void blockHitted()
    {
        Destroy(gameObject, 0.1f);
    }
}
