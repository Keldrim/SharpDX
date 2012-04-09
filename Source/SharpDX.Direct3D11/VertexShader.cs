﻿// Copyright (c) 2010-2011 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
#if !WIN8
using SharpDX.D3DCompiler;
#endif

namespace SharpDX.Direct3D11
{
    public partial class VertexShader
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:SharpDX.Direct3D11.VertexShader" /> class.
        /// </summary>
        /// <param name = "device">The device used to create the shader.</param>
        /// <param name = "shaderBytecode">The compiled shader bytecode.</param>
        public VertexShader(Device device, byte[] shaderBytecode) : this(device, shaderBytecode, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:SharpDX.Direct3D11.VertexShader" /> class.
        /// </summary>
        /// <param name = "device">The device used to create the shader.</param>
        /// <param name = "shaderBytecode">The compiled shader bytecode.</param>
        /// <param name = "linkage">A dynamic class linkage interface.</param>
        public VertexShader(Device device, byte[] shaderBytecode, ClassLinkage linkage)
            : base(IntPtr.Zero)
        {
            if (shaderBytecode == null) throw new ArgumentNullException("shaderBytecode", "ShaderBytecode cannot be null");

            unsafe
            {
                fixed (void* pBuffer = shaderBytecode)
                    device.CreateVertexShader((IntPtr)pBuffer, shaderBytecode.Length, linkage, this);
            }
        }

#if !WIN8
        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:SharpDX.Direct3D11.VertexShader" /> class.
        /// </summary>
        /// <param name = "device">The device used to create the shader.</param>
        /// <param name = "shaderBytecode">The compiled shader bytecode.</param>
        public VertexShader(Device device, ShaderBytecode shaderBytecode)
            : this(device, shaderBytecode, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:SharpDX.Direct3D11.VertexShader" /> class.
        /// </summary>
        /// <param name = "device">The device used to create the shader.</param>
        /// <param name = "shaderBytecode">The compiled shader bytecode.</param>
        /// <param name = "linkage">A dynamic class linkage interface.</param>
        public VertexShader(Device device, ShaderBytecode shaderBytecode, ClassLinkage linkage)
            : base(IntPtr.Zero)
        {
            if (shaderBytecode == null) throw new ArgumentNullException("shaderBytecode", "ShaderBytecode cannot be null");

            device.CreateVertexShader(shaderBytecode.BufferPointer,
                                      shaderBytecode.BufferSize, linkage, this);
        }
#endif
    }
}