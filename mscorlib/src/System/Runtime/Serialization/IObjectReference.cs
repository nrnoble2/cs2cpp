// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/*============================================================
**
** Interface: IObjectReference
**
**
** Purpose: Implemented by objects that are actually references
**          to a different object which can't be discovered until
**          this one is completely restored.  During the fixup stage,
**          any object implementing IObjectReference is asked for it's
**          "real" object and that object is inserted into the graph.
**
**
===========================================================*/
namespace System.Runtime.Serialization {

    using System;
    using System.Security.Permissions;
    // Interface does not need to be marked with the serializable attribute
[System.Runtime.InteropServices.ComVisible(true)]
    public interface IObjectReference {
        [System.Security.SecurityCritical]  // auto-generated_required
        Object GetRealObject(StreamingContext context);
    }
}


