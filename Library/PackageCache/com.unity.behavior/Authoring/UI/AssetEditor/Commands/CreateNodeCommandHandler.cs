﻿using Unity.Behavior.GraphFramework;

namespace Unity.Behavior
{
    internal class CreateNodeCommandHandler : CommandHandler<CreateNodeCommand>
    {
        public override bool Process(CreateNodeCommand command)
        {
            NodeModel newNode = Asset.CreateNode(command.NodeType, command.Position, null, command.Args);

            // Connect default LinkField variables to fields.
            if (DispatcherContext is BehaviorGraphEditor behaviorGraphEditor &&
                newNode is BehaviorGraphNodeModel behaviorGraphNodeModel)
            {
                behaviorGraphEditor.LinkVariablesFromBlackboard(behaviorGraphNodeModel);
                behaviorGraphEditor.LinkRecentlyLinkedFields(behaviorGraphNodeModel);
                behaviorGraphNodeModel.OnValidate();
            }

            if (command.SequenceToAddTo != null && newNode.IsSequenceable)
            {
                Asset.AddNodeToSequence(newNode, command.SequenceToAddTo, command.SequenceToAddTo.Nodes.Count);
                return true;
            }

            void AlignNewNode()
            {
                SelectAndAlignNode(newNode);
                GraphView.ViewState.ViewStateUpdated -= AlignNewNode;
            }
            GraphView.ViewState.ViewStateUpdated += AlignNewNode;
            

            if (command.ConnectedPort == null)
            {
                return true;
            }

            // Get the relevant port to connect to.
            PortModel connectedPort = command.ConnectedPort;
            PortModel newNodePort;
            if (connectedPort.IsInputPort)
            {
                newNode.TryDefaultOutputPortModel(out newNodePort);
            }
            else
            {
                newNode.TryDefaultInputPortModel(out newNodePort);
            }

            // If the new node does not have a valid port to connect to, return without connecting.
            if (newNodePort == null)
            {
                return true;
            }

            PortModel outputPortModel = connectedPort.IsOutputPort ? connectedPort : newNodePort;
            PortModel inputPortModel = connectedPort.IsInputPort ? connectedPort : newNodePort;
            BehaviorGraphView graphView = GraphView as BehaviorGraphView;

            graphView!.ConnectPorts(outputPortModel, inputPortModel);

            return true;
        }

        private void SelectAndAlignNode(NodeModel newNode)
        {
            GraphView.schedule.Execute(_ =>
            {
                if (GraphView.ViewState.m_NodeModelToNodeUI.TryGetValue(newNode.ID, out NodeUI nodeUI))
                {
                    GraphView.ViewState.DeselectAll();
                    GraphView.ViewState.AddSelected(nodeUI);
                    GraphUILayoutUtility.AlignSelectedNodesImmediateChildren(GraphView);
                }
            });
        }
    }
}