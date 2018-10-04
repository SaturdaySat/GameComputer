using UnityEditor;
using UnityEngine;

public class MyTools : EditorWindow {
    [MenuItem("Window/MyTools")]
    


    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(MyTools));
    }

    void OnGUI()
    {
        int partId =  EditorGUILayout.IntField("PartId :", 0);
        int partIcon = EditorGUILayout.IntField("PartIcon :", 0);
        string partName = EditorGUILayout.TextField("PartName", "ASUS");
        string partDesc = EditorGUILayout.TextField("PartDesc", "这是一个描述");
        int durability = EditorGUILayout.IntField("Durability :", 0);
        int price = EditorGUILayout.IntField("Price :", 0);

        if (GUILayout.Button("添加MotherBoard"))
        {
            MotherBoard motherBoard = new MotherBoard(ComputerPartType.MotherBoard, partId, partIcon, partName, partDesc, durability, price, null);
            if (ActorHelper.GetInstance().GetHostActor().vaultComponent.AddMotherBoard(motherBoard))
            {
                Debug.Log("添加MotherBoard 成功");
            }
            else
            {
                Debug.Log("添加MotherBoard 失败");
            }
        }
    }


}
