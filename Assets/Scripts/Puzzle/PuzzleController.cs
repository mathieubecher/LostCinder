using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public List<Puzzle> puzzles;
    public List<Puzzle> instances;
    public Puzzle actualPuzzle;
    public Controller character;
    public Cinder cinder;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Puzzle p in puzzles)
        {
            InstantiatePuzzle(p);
        }
        actualPuzzle = instances[0];
        for(int i = 0; i < instances.Count; i++)
        {
            if (instances[i].id < actualPuzzle.id)
            {
                actualPuzzle = instances[i];
            }
        }
        actualPuzzle.Retry();
    }

    // Update is called once per frame
    void Update()
    {
        actualPuzzle.progress.UpdateCinder();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int id = actualPuzzle.id;
            instances.Remove(actualPuzzle);
            Destroy(actualPuzzle.gameObject);
            actualPuzzle = null;
            int i = 0;
            while (i < puzzles.Count && puzzles[i].id != id) i++;
            actualPuzzle = InstantiatePuzzle(puzzles[i]);
            actualPuzzle.Retry();
        }
        if (actualPuzzle.progress.progress >= 1)
        {
            Debug.Log("change");
            instances.Remove(actualPuzzle);
            actualPuzzle = GetFirst();
        }

    }

    Puzzle InstantiatePuzzle(Puzzle p)
    {
        Puzzle instance = Instantiate(p, transform);
        instance.character = character;
        instance.cinder = cinder;
        instances.Add(instance);
        return instance;
    }
    Puzzle GetFirst()
    {
        Puzzle firstpuzzle = instances[0];
        for (int i = 0; i < instances.Count; i++)
        {
            if (instances[i].id < firstpuzzle.id)
            {
                firstpuzzle = instances[i];
            }
        }
        return firstpuzzle;
    }
}
