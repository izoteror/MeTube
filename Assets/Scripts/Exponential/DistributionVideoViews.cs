using UnityEngine;
using System.Collections;
using System;

public class DistributionVideoViews : MonoBehaviour 
{
	public float exponent = 2.0f;
	public static DistributionVideoViews DistributionST;
	private RandomFromDistribution.Direction_e direction = RandomFromDistribution.Direction_e.Right;

	private void Awake()
	{
		if (DistributionST != null)
			Destroy(this);
		if (DistributionST == null)
			DistributionST = this;
	}

	public int CreateGraph(int repetitions, int min,int max,int playerbucket,GameObject videoObj)
	{
		int[] buckets = new int[max+1 - min]; 
		for (int i = 0; i < buckets.Length; ++i) {
			buckets[i] = 0;
		}
		
		for (int i = 0; i < repetitions; ++i) {
			float bucket =  RandomFromDistribution.RandomRangeExponential(min, max, exponent, direction);
			
			buckets[Mathf.RoundToInt(bucket) - min] ++;
		}

		if (playerbucket > max)
			playerbucket = max;
		if (playerbucket < min)
			playerbucket = min;

		repetitions -= buckets[playerbucket];
		return buckets[playerbucket];	
	}
}
