using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketManager : Singleton<BucketManager>
{
    List<Bucket> buckets = new List<Bucket>();
    List<Bucket> fullBuckets = new List<Bucket>();

    public void RegisterBucket(Bucket bucket)
    {
        buckets.Add(bucket);
    }

    public void AddFullBucket(Bucket bucket)
    {
        if (fullBuckets.Contains(bucket)) { return; }

        fullBuckets.Add(bucket);
        if (fullBuckets.Count == buckets.Count)
        {
            GameManager.Instance.ChangeState(GameState.GAME_WON);
        }
    }
}
