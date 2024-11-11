/*
 * Muse API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Unity.Behavior.WebApi.Client.OpenAPIDateConverter;

namespace Unity.Behavior.WebApi.Model
{
    /// <summary>
    /// Enum for the type of script being repaired.
    /// </summary>
    /// <value>Enum for the type of script being repaired.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum ScriptType
    {
        /// <summary>
        /// Enum AgentAction for value: agent_action
        /// </summary>
        [EnumMember(Value = "agent_action")]
        AgentAction = 1,

        /// <summary>
        /// Enum Monobehaviour for value: monobehaviour
        /// </summary>
        [EnumMember(Value = "monobehaviour")]
        Monobehaviour = 2
    }

}