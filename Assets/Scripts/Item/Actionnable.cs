using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionnable : MonoBehaviour
{
    public float beginAngle = 0;
    public float endAngle = 0;
    public Vector3 beginPos = new Vector3(0,0);
    public Vector3 endPos = new Vector3(0, 0);
    public float time = 1;
    public float timer = 0;
    public bool begin = false;
    public bool revertable = false;
    public bool chain = false;
    public bool linear = false;
    private bool isbegin = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        beginAngle += transform.eulerAngles.z;
        endAngle += transform.eulerAngles.z;
        if (begin)
        {
            beginPos += transform.position;
            endPos += transform.position;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (time > 0) { 
            if (timer <= time || chain)
            {
                if (begin) { 
                    timer += Time.deltaTime;
                    if (timer > time && !chain) timer = time;
                    else timer = timer % time;
                }
                else if (revertable)
                {
                    timer -= Time.deltaTime;
                    if (timer < 0) timer = 0;
                }
                if(begin || revertable) { 
                    float progress = AnimProgress();
                    transform.position = Vector3.Lerp(beginPos, endPos, progress);
                    transform.eulerAngles = new Vector3(0, 0, beginAngle + (endAngle - beginAngle) * progress);
                }
            }
        }
    }

    public virtual float AnimProgress()
    {
        float start = 0;
        float end = 1;
        float value = timer / time;
        if (linear) return value;

        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value + start;
        value--;
        return -end * 0.5f * (value * (value - 2) - 1) + start;
    }

    public virtual void Action()
    {
        if (!isbegin)
        {
            isbegin = true;
            beginPos += transform.position;
            endPos += transform.position;
        }
        begin = !begin;
    }
}
