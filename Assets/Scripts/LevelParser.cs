using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }
    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    // Call spawn prefab
                    SpawnPrefab(letter, new Vector3(column, -row, -0.5f));
                    column++;
                }
                row++;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'o': ToSpawn = Enemy1; break;
            case 't': ToSpawn = Enemy2; break;
            case 'e': ToSpawn = Enemy3; break;
            case 'f': ToSpawn = Enemy4; break;
            default: return;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }
    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Enemy";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;

        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
