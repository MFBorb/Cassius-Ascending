using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct node {

    public node(int State, GameObject Prefab) {
        state = State;
        prefab = Prefab;
    }

    public int state;
    public GameObject prefab;
}

public class GenerateTiles : MonoBehaviour
{
    // Variable declaration

    // Constant declarations
    public const int NOT_VISITED = 0;
    public const int VISITED = 1;
    public const int SKIP = 2;

    // Public variables

    // These are the arrays that hold all of the tile prefabs.
    public GameObject[] oneTilePrefabs;
    public GameObject[] longTilePrefabs;
    public GameObject[] wideTilePrefabs;
    public GameObject[] twoByTwoTilePrefabs;
    public GameObject spawnTilePrefab;

    // Floats that will hold the weights for how often the tiles will spawn in.
    // Needs to add up to 1
    public float oneTileWeight;
    public float longTileWeight;
    public float wideTileWeight;
    public float twoByTwoTileWeight;

    // Private variables
    // Create an array that stores a node for each tile we will have (7x4 grid)
    private node[] tileArray = new node[28];

    // Start is called before the first frame update
    void Start()
    { 
        initializeWeights();
        initializeStartNode();
        generateRandomTiles();
        instantiateRandomTiles();
    }

    void initializeWeights() {
        wideTileWeight += twoByTwoTileWeight;
        longTileWeight += wideTileWeight;
        oneTileWeight += longTileWeight;
    }

    // We want the start node to be at the same place every time. This is node 10 and 17 since the
    // start node is a long node and in the middle
    void initializeStartNode() {
        tileArray[10].state = 1;
        tileArray[10].prefab = spawnTilePrefab;
        tileArray[17].state = 2;
    }

    void generateRandomTiles() {
        // Generate a tile for each node in the tile array
        for (int i = 0; i < tileArray.Length; i++) {

            node currentNode = tileArray[i];

            // Check to make sure we haven't messed with this node before
            if (currentNode.state == 0) {
                
                // Generate a random weight to check against our weights for each node.
                float randomFloat = Random.Range(0.0f, 1.0f);

                // We'll check in reverse order. We can do a little trick with this
                // to make sure the 1 tile is defaulted to.
                if (randomFloat <= twoByTwoTileWeight) {
                    // Can we place a twoByTwoTile here? (Not on bottom row, right edge, and the surrounding nodes are empty)
                    if (i < 21 && i % 7 != 6 && tileArray[i + 1].state == 0 &&
                        tileArray[i + 7].state == 0 && tileArray[i + 8].state == 0) {
                        
                        currentNode.state = 1;
                        currentNode.prefab = twoByTwoTilePrefabs[Random.Range(0, twoByTwoTilePrefabs.Length)];

                        tileArray[i + 1].state = 2;
                        tileArray[i + 7].state = 2;
                        tileArray[i + 8].state = 2;
                    }
                }
                else if (randomFloat <= wideTileWeight) {
                    // Can we place a wideTile here? (Not on right edge and the surrounding nodes are empty)
                    if (i % 7 != 6 && tileArray[i + 1].state == 0) {
                        currentNode.state = 1;
                        currentNode.prefab = wideTilePrefabs[Random.Range(0, wideTilePrefabs.Length)];

                        tileArray[i + 1].state = 2;
                    }
                }
                else if (randomFloat <= longTileWeight) {
                    // Can we place a longTile here? (Not on bottom row and the surrounding nodes are empty)
                    if (i < 21 && tileArray[i + 7].state == 0) {
                        currentNode.state = 1;
                        currentNode.prefab = longTilePrefabs[Random.Range(0, longTilePrefabs.Length)];

                        tileArray[i + 7].state = 2;
                    }
                }

                // If after all of that, the node has not been changed, we place a 1 tile node.
                if (currentNode.state == 0) {
                    currentNode.state = 1;
                    currentNode.prefab = oneTilePrefabs[Random.Range(0, oneTilePrefabs.Length)];
                }
            }

            tileArray[i] = currentNode;
        }
    }

    // This is the tricky part. We wanna make it corresponding to the tile generator and with an
    // x, y offset depending on the node we're currently in. We can calculate this by extracting the
    // x and y tile coordinate (i.e tile 17 being tile 2, 3) and multiplying that by a base x, y offset
    // that will be hard coded into the function.
    void instantiateRandomTiles() {
        float xOffset = 2.25f;
        float yOffset = -2.0f;

        float parentX = transform.position.x;
        float parentY = 4.25f;
        float parentZ = transform.position.z;

        for (int i = 0; i < tileArray.Length; i++) {
            node currentNode = tileArray[i];

            // Do we need to instantiate a node?
            if (currentNode.state == 1) {

                int tileX = i % 7;
                int tileY = i / 7;

                Instantiate(currentNode.prefab, new Vector3(parentX + tileX * xOffset, parentY + tileY * yOffset, parentZ), transform.rotation);
            }
        }
    }
}
