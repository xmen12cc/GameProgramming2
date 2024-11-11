using System;

namespace Unity.Behavior.GraphFramework
{
    internal class CreateVariableCommand : Command
    {
        public string Name { get; }
        public Type VariableType { get; }
        public object[] Args { get; }
        
        public CreateVariableCommand(string name, Type variableType, params object[] args) : base(true)
        {
            Name = name;
            VariableType = variableType;
            Args = args;
        }
    }
}
