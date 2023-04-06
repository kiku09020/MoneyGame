using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

using static MyEditor.EditorTemplate;

[CustomEditor(typeof(HitCheckerBase),true)]
public class HitCheckManagementEditor : Editor
{

    //--------------------------------------------------

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var targ = target as HitCheckerBase;

        Space(SpaceType.vertical);
        EditorGUILayout.LabelField("Options", EditorStyles.boldLabel);
        targ.enabled = Group.ToggleGroup(targ.enabled, "Enable", Direction.vertical,  () => {

            // Tag
            targ.isEnableTag = Group.ToggleGroup(targ.isEnableTag, "EnableTag", Direction.vertical, () => {
                targ.targetTag = EditorGUILayout.TagField("targetTag", targ.targetTag);
            });

            // LayerMask
            targ.isEnableLayerMask = Group.ToggleGroup(targ.isEnableLayerMask, "EnableLayer", Direction.vertical, () => {
                var mask = InternalEditorUtility.LayerMaskToConcatenatedLayersMask(targ.targetLayerMask);

                var layerMask = EditorGUILayout.MaskField("LayerMask", mask, InternalEditorUtility.layers);     // mask•\Ž¦
                targ.targetLayerMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(layerMask);      // mask“K—p
            });
        });
    }

}
