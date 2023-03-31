using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SelectTagged : ScriptableWizard
    {
        public String searchTag = "Enter tag";

        [MenuItem("Mikkis Tools/Select Tagged")]
        static void SelectTaggedWizard()
        {
            ScriptableWizard.DisplayWizard<SelectTagged>("Select Tagged Objects", "Make Selection");
        }

        private void OnWizardCreate()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
            Selection.objects = gameObjects;
        }
    }
}
