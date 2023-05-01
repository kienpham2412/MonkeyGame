using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoUtility
{
    #region "Transform"
    public static List<Vector3> CreateListOfCirclePos(float radius, int numberOfPosition, Vector3 offset)
    {
        List<Vector3> listOfPos = new List<Vector3>();
        for (int i = 0; i < numberOfPosition; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfPosition;
            listOfPos.Add(new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius) + offset);
        }

        return listOfPos;
    }

    public static List<Vector3> CreateListOfCirclePos(float radius, int numberOfPosition)
    {
        List<Vector3> listOfPos = new List<Vector3>();
        for (int i = 0; i < numberOfPosition; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfPosition;
            listOfPos.Add(new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius));
        }

        return listOfPos;
    }

    public static Vector3 GetPointInBezier(Vector3 start, Vector3 startHandle, Vector3 destinationHandle, Vector3 destination, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * start +
            3f * oneMinusT * oneMinusT * t * startHandle +
            3f * oneMinusT * t * t * destinationHandle +
            t * t * t * destination;
    }
    #endregion

    #region GameObject
    /// <summary>
    /// Return the first found component in children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static T GetComponentInChildrenOnly<T>(this GameObject gameObject) where T : Component
    {
        T[] components = gameObject.GetComponentsInChildren<T>();
        foreach (T component in components)
        {
            if (component.gameObject != gameObject) return component;
        }

        return null;
    }

    /// <summary>
    /// Return all found components in children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static T[] GetComponentsInChildrenOnly<T>(this GameObject gameObject) where T : Component
    {
        T[] components = gameObject.GetComponentsInChildren<T>();
        List<T> list = new List<T>();
        foreach (T component in components)
        {
            if (component.gameObject != gameObject) list.Add(component);
        }

        return list.ToArray();
    }
    #endregion

    #region "ArrayNList"
    /// <summary>
    /// Return a random member of list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T Random<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    /// <summary>
    /// Return a random member of array
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static T Random<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static void Shuffle<T>(this List<T> list)
    {
        int index;
        int maxCount = list.Count;
        T temp;
        for (int i = list.Count - 1; i >= 1; i--)
        {
            index = UnityEngine.Random.Range(0, i);
            temp = list[i];
            list[i] = list[index];
            list[index] = temp;
        }
    }

    public static void Shuffle<T>(this T[] list)
    {
        int index;
        int maxCount = list.Length;
        T temp;
        for (int i = list.Length - 1; i >= 1; i--)
        {
            index = UnityEngine.Random.Range(0, i);
            temp = list[i];
            list[i] = list[index];
            list[index] = temp;
        }
    }

    public static string ConvertToString(this int[] array)
    {
        string result = "";
        for (int i = 0; i < array.Length; i++)
            result += array[i].ToString() + " ";

        return result;
    }
    #endregion

    #region "Time"
    public static void SetTimeScale<T>(this T monobehaviour, int timeScaleValue)
    {
        Time.timeScale = timeScaleValue;
        Debug.Log($"Timescale is set to {timeScaleValue} by {monobehaviour.GetType()}");
    }

    #endregion

    #region "Rating"
    public static bool GetTrueByRate(int rate)
    {
        if (rate >= 100) return true;
        return UnityEngine.Random.Range(1, 101) <= rate;
    }

    public static bool GetTrueByRate(float rate)
    {
        if (rate >= 100) return true;
        return UnityEngine.Random.Range(0.1f, 100) <= rate;
    }
    #endregion

    #region Color Maker
    public static string AddColor(int content, string hexaColor)
    {
        string colorContent = $"<COLOR={hexaColor}>{content}</color>";
        return colorContent;
    }

    public static string AddColor(float content, string hexaColor)
    {
        string colorContent = $"<COLOR={hexaColor}>{content}</color>";
        return colorContent;
    }

    public static string AddColor(string content, string hexaColor)
    {
        string colorContent = $"<COLOR={hexaColor}>{content}</color>";
        return colorContent;
    }
    #endregion
}
