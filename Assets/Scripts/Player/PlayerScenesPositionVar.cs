
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Player位置加载器
 *存档
 */
public class PlayerScenesPositionVar
{
    public static PlayerScenesPositionVar instance = new PlayerScenesPositionVar();
    //位置
    List<ScPosition> scPozations = new List<ScPosition>();
    //游戏进度
   
    private PlayerScenesPositionVar() { instance = this; }

    public void load(Vector2 position)
    {
        load(SceneManager.GetActiveScene().name, position);
    }
    public void load(string name, Vector2 position )
    {
        foreach( ScPosition p in scPozations)
        {

            if (p.Name == name) 
            { 
                p.Position = position; return; 
            } 
        }
        scPozations.Add(new ScPosition( name, position));
    }
    public Vector2 getPosition()
    {
        return getPosition(SceneManager.GetActiveScene().name);
    }
    public Vector2 getPosition(string SceneName)
    {
        if (SceneName == "FrameWorld") return GameManager.instant.Scene0framePosition();
        foreach ( ScPosition p in scPozations) 
        { 
            if (p.Name == SceneName) 
            {
                Vector2 c = Camera.main.transform.position;
                Vector2 a = p.Position;
                c.x = (c - a).x;
                a.x += c.x/math.abs(c.x)*3;
                a.y += 1;
                return a;
            } 
        }
        return GameManager.instant.getPlayer().transform.position;
    }
    class ScPosition
    {
        public ScPosition(string name, Vector2 position)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; set; }
        public Vector2 Position { get; set; }
    }    

}
