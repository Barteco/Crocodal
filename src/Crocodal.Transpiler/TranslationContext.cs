using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace Crocodal.Transpiler
{
    internal class TranslationContext
    {
        public SemanticModel Model { get;  }

        private int CurrentNodeIndex { get; set; }
        private Type RightSideType { get; set; }
        private Dictionary<string, Type> Variables { get; } = new Dictionary<string, Type>();

        public TranslationContext(SemanticModel model)
        {
            Model = model;
        }

        public void SetRightSideType(Type type)
        {
            RightSideType = type;
        }

        public void TrackVariable(string name, Type type)
        {
            Variables.Add(name, type);
        }

        public TranslationContext WithIndex(int i)
        {
            CurrentNodeIndex = i;
            return this;
        }

        public void ResetIndex()
        {
            CurrentNodeIndex = -1;
        }

        public Type GetVariableType(string name)
        {
            if (Variables.ContainsKey(name))
            {
                return Variables[name];
            }

            if (RightSideType != null && RightSideType.IsGenericType && CurrentNodeIndex >= 0)
            {
                return RightSideType.GenericTypeArguments[CurrentNodeIndex];
            }

            return RightSideType;
        }
    }
}
