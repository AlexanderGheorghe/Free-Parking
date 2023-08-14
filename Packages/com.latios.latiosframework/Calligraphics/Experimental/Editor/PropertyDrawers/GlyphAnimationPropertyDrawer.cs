using System;
using Latios.Calligraphics.Authoring;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Latios.Calligraphics.Editor
{
    [CustomPropertyDrawer(typeof(GlyphAnimation))]
    public class GlyphAnimationPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();

            var transitionValueProperty = property.FindPropertyRelative("transitionValue");
            var transitionValueField = new PropertyField(transitionValueProperty);
            root.Add(transitionValueField);
            var interpolationField = new PropertyField(property.FindPropertyRelative("interpolation"));
            root.Add(interpolationField);
            var animationStyleProperty = property.FindPropertyRelative("animationStyle");
            var animationStyleField = new PropertyField(animationStyleProperty);
            root.Add(animationStyleField);
            var scopeProperty = property.FindPropertyRelative("scope");
            var scopeField = new PropertyField(scopeProperty);
            root.Add(scopeField);
            var startIndexField = new PropertyField(property.FindPropertyRelative("startIndex"));
            root.Add(startIndexField);
            var endIndexField = new PropertyField(property.FindPropertyRelative("endIndex"));
            root.Add(endIndexField);
            var transitionDurationField = new PropertyField(property.FindPropertyRelative("transitionDuration"));
            root.Add(transitionDurationField);
            var transitionTimeOffsetField = new PropertyField(property.FindPropertyRelative("transitionTimeOffset"));
            root.Add(transitionTimeOffsetField);
            var progressiveTimeOffsetField = new PropertyField(property.FindPropertyRelative("progressiveTimeOffset"));
            root.Add(progressiveTimeOffsetField);
            var endBehaviorProperty = property.FindPropertyRelative("endBehavior");
            var endBehaviorField = new PropertyField(endBehaviorProperty);
            root.Add(endBehaviorField);
            var loopCountField = new PropertyField(property.FindPropertyRelative("loopCount"));
            root.Add(loopCountField);
            var loopDelayField = new PropertyField(property.FindPropertyRelative("loopDelay"));
            root.Add(loopDelayField);
            var pingPongField = new PropertyField(property.FindPropertyRelative("pingPong"));
            root.Add(pingPongField);
            var startValueByteField = new PropertyField(property.FindPropertyRelative("startValueByte"));
            root.Add(startValueByteField);
            var endValueByteField = new PropertyField(property.FindPropertyRelative("endValueByte"));
            root.Add(endValueByteField);
            var startValueFloatField = new PropertyField(property.FindPropertyRelative("startValueFloat"));
            root.Add(startValueFloatField);
            var endValueFloatField = new PropertyField(property.FindPropertyRelative("endValueFloat"));
            root.Add(endValueFloatField);
            var startValueColorField = new PropertyField(property.FindPropertyRelative("startValueColor"));
            root.Add(startValueColorField);
            var endValueColorField = new PropertyField(property.FindPropertyRelative("endValueColor"));
            root.Add(endValueColorField);
            var startValueFloat2Field = new PropertyField(property.FindPropertyRelative("startValueFloat2"));
            root.Add(startValueFloat2Field);
            var endValueFloat2Field = new PropertyField(property.FindPropertyRelative("endValueFloat2"));
            root.Add(endValueFloat2Field);
            var noiseScaleFloatField = new PropertyField(property.FindPropertyRelative("noiseScaleFloat"));
            root.Add(noiseScaleFloatField);
            var noiseScaleFloat2Field = new PropertyField(property.FindPropertyRelative("noiseScaleFloat2"));
            root.Add(noiseScaleFloat2Field);
            var startValueFloat3Field = new PropertyField(property.FindPropertyRelative("startValueFloat3"));
            root.Add(startValueFloat3Field);
            var endValueFloat3Field = new PropertyField(property.FindPropertyRelative("endValueFloat3"));
            root.Add(endValueFloat3Field);

            Action<int> hideShowLoopFields = (enumValue) =>
            {
                var endBehavior = (TransitionEndBehavior)enumValue;
                if ((endBehavior & TransitionEndBehavior.Loop) == TransitionEndBehavior.Loop)
                {
                    loopCountField.style.display = DisplayStyle.Flex;
                    loopDelayField.style.display = DisplayStyle.Flex;
                }
                else
                {
                    loopCountField.style.display = DisplayStyle.None;
                    loopDelayField.style.display = DisplayStyle.None;
                }
            };
            endBehaviorField.RegisterValueChangeCallback(e =>
            {
                hideShowLoopFields(e.changedProperty.enumValueIndex);
            });
            hideShowLoopFields(endBehaviorProperty.enumValueIndex);

            Action<int> hideShowAnimationStyleFields = (enumValue) =>
            {
                var animationStyle = (AnimationStyle)enumValue;
                if (animationStyle == AnimationStyle.Progressive)
                {
                    progressiveTimeOffsetField.style.display = DisplayStyle.Flex;
                }
                else
                {
                    progressiveTimeOffsetField.style.display = DisplayStyle.None;
                }
            };
            animationStyleField.RegisterValueChangeCallback(e =>
            {
                hideShowAnimationStyleFields(e.changedProperty.enumValueIndex);
            });
            hideShowAnimationStyleFields(transitionValueProperty.enumValueIndex);

            Action<int> hideShowScopeFields = (enumValue) =>
            {
                var scope = (TextScope)enumValue;
                switch (scope)
                {
                    case TextScope.All:
                    {
                        startIndexField.style.display = DisplayStyle.None;
                        endIndexField.style.display = DisplayStyle.None;
                        break;
                    }
                    default:
                    {
                        startIndexField.style.display = DisplayStyle.Flex;
                        endIndexField.style.display = DisplayStyle.Flex;
                        break;
                    }
                }
            };
            scopeField.RegisterValueChangeCallback(e =>
            {
                hideShowScopeFields(e.changedProperty.enumValueIndex);
            });
            hideShowScopeFields(scopeProperty.enumValueIndex);

            Action<int> hideShowAnimationTypeFields = (enumValue) =>
            {
                var animationType = (TransitionValue)enumValue;
                switch (animationType)
                {
                    case TransitionValue.Opacity:
                    {
                        startValueByteField.style.display = DisplayStyle.Flex;
                        endValueByteField.style.display = DisplayStyle.Flex;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.None;
                        endValueColorField.style.display = DisplayStyle.None;
                        startValueFloat2Field.style.display = DisplayStyle.None;
                        endValueFloat2Field.style.display = DisplayStyle.None;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.None;
                        noiseScaleFloatField.style.display = DisplayStyle.None;
                        break;
                    }
                    case TransitionValue.Scale:
                    {
                        startValueByteField.style.display = DisplayStyle.None;
                        endValueByteField.style.display = DisplayStyle.None;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.None;
                        endValueColorField.style.display = DisplayStyle.None;
                        startValueFloat2Field.style.display = DisplayStyle.Flex;
                        endValueFloat2Field.style.display = DisplayStyle.Flex;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.None;
                        noiseScaleFloatField.style.display = DisplayStyle.None;
                        break;
                    }
                    case TransitionValue.Color:
                    {
                        startValueByteField.style.display = DisplayStyle.None;
                        endValueByteField.style.display = DisplayStyle.None;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.Flex;
                        endValueColorField.style.display = DisplayStyle.Flex;
                        startValueFloat2Field.style.display = DisplayStyle.None;
                        endValueFloat2Field.style.display = DisplayStyle.None;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.None;
                        noiseScaleFloatField.style.display = DisplayStyle.None;
                        break;
                    }
                    case TransitionValue.Position:
                    {
                        startValueByteField.style.display = DisplayStyle.None;
                        endValueByteField.style.display = DisplayStyle.None;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.None;
                        endValueColorField.style.display = DisplayStyle.None;
                        startValueFloat2Field.style.display = DisplayStyle.Flex;
                        endValueFloat2Field.style.display = DisplayStyle.Flex;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.None;
                        noiseScaleFloatField.style.display = DisplayStyle.None;
                        break;
                    }
                    case TransitionValue.NoisePosition:
                    {
                        startValueByteField.style.display = DisplayStyle.None;
                        endValueByteField.style.display = DisplayStyle.None;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.None;
                        endValueColorField.style.display = DisplayStyle.None;
                        startValueFloat2Field.style.display = DisplayStyle.None;
                        endValueFloat2Field.style.display = DisplayStyle.None;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.Flex;
                        noiseScaleFloatField.style.display = DisplayStyle.None;
                        break;
                    }
                    case TransitionValue.NoiseRotation:
                    {
                        startValueByteField.style.display = DisplayStyle.None;
                        endValueByteField.style.display = DisplayStyle.None;
                        startValueFloatField.style.display = DisplayStyle.None;
                        endValueFloatField.style.display = DisplayStyle.None;
                        startValueColorField.style.display = DisplayStyle.None;
                        endValueColorField.style.display = DisplayStyle.None;
                        startValueFloat2Field.style.display = DisplayStyle.None;
                        endValueFloat2Field.style.display = DisplayStyle.None;
                        startValueFloat3Field.style.display = DisplayStyle.None;
                        endValueFloat3Field.style.display = DisplayStyle.None;
                        noiseScaleFloat2Field.style.display = DisplayStyle.None;
                        noiseScaleFloatField.style.display = DisplayStyle.Flex;
                        break;  
                    }
                }
            };
            transitionValueField.RegisterValueChangeCallback(e =>
            {
                hideShowAnimationTypeFields(e.changedProperty.enumValueIndex);
            });
            hideShowAnimationTypeFields(transitionValueProperty.enumValueIndex);

            return root;
        }
    }
}