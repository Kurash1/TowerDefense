using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcExtensions;
using UnityEngine.UI;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    [SerializeField] float CameraSpeed = 10f;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject zombie;
    Plane plane = new Plane(Vector3.up, 0);
    GameObject[,] board = new GameObject[10, 10];
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(() => {
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
            Spawnit();
        });
    }
    void Spawnit()
    {
        GameObject zz = Instantiate(zombie);
        zz.SetActive(true);
        NavMeshAgent agent = zz.GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(5, 0, -6));
        zz.AddComponent<GoalOriented>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * CameraSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * CameraSpeed;

        transform.position += new Vector3(x,0,y);

        if (Input.GetMouseButtonDown(1))
            SpawnAtMouse(cube);
    }
    GameObject? SpawnAtMouse(GameObject cube)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 pos = ray.GetPoint(distance);
            pointVector2 click = new pointVector2(pos.x.toRange(-5, 4), pos.z.toRange(-5, 4));
            if (board[click.x + 5, click.y + 5] == null)
            {
                GameObject newcube = Instantiate(cube);
                newcube.transform.position = pos;
                newcube.transform.position = click.toVector3();
                newcube.AddComponent<NavMeshObstacle>().carving = true;
                board[click.x + 5, click.y + 5] = newcube;
                
                if(true)
                    return newcube;
                else
                    Destroy(board[click.x + 5, click.y + 5]);
            }
            else
            {
                Destroy(board[click.x + 5, click.y + 5]);
            }
        }
        return null;
    }
}
class pointVector2
{
    public int x;
    public int y;
    public pointVector2(float x, float y)
    {
        this.x = (int)Mathf.Round(x);
        this.y = (int)Mathf.Round(y);
    }
    public pointVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Vector3 toVector3()
    {
        return new Vector3(x, 0, y);
    }
}