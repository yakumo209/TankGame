using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int r= Random.Range(0, 100);//[0,100)
        print(r);
        float fr = Random.Range(0, 99f);
        print(fr);
        //委托
        System.Action action = () =>
        {
            print("123");
        };
        action.Invoke();
        System.Action<int, float> action2 = (i, f) =>
        {
            print(i +" "+ f);
        };
        action2.Invoke(1,3f);
        System.Func<int> func = () =>
        {
            return 1;
        };
        func.Invoke();
        System.Func<int, string> func2 = (i) =>
        {
            return i.ToString();
        };
        func2.Invoke(2);


        UnityAction uac = () =>
        {

        };
        UnityAction<string> uac2 = (s) =>
        {
            
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
