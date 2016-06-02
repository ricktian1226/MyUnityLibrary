using System;
using System.Collections;
using UnityEngine;

namespace MyUnityLibrary
{
    public class CoroutineAPI
    {
        /// <summary>
        /// 定时器，在实际使用中通过调用 StartCoroutine(Wait(<秒数>)) 就可以了
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}
