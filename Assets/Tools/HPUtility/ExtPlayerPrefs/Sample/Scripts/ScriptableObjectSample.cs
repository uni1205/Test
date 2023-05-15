using HKUtility;
using UnityEngine;

namespace ExtPlayerPrefsSample
{
    public class ScriptableObjectSample : MonoBehaviour
    {
        [SerializeField]
        ScriptableCreate data;

        void Update()
        {
            // 保存
            if (Input.GetKeyDown(KeyCode.S))
            {
                data.hp++;
                data.itemList.Add(new ScriptableCreate.MyItem { name = "りんご", number = 3 });

                var json = ExtPlayerPrefs.Save(data, "data");

                // 表示
                print(json);
            }

            // 読み出し
            if (Input.GetKeyDown(KeyCode.L))
            {
                ExtPlayerPrefs.Load(data, "data");

                // 表示
                print(data["りんご"]);

                foreach (var item in data.itemList)
                {
                    print($"{item.name} : {item.number}");
                }
            }

            // データクリア
            if (Input.GetKeyDown(KeyCode.C))
            {
                data.hp = 0;
                data.itemList.Clear();

                ExtPlayerPrefs.Save(data, "data");
            }
        }
    }
}