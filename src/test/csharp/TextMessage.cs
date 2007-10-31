/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using NUnit.Framework;

namespace Apache.NMS.Test
{
    [TestFixture]
    public abstract class TextMessage : NMSTestSupport
    {
        private string expected = "Hello World!";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

        [Test]
        public override void SendAndSyncReceive()
        {
            base.SendAndSyncReceive();
        }

        protected override IMessage CreateMessage()
        {
            IMessage request = Session.CreateTextMessage(expected);
            return request;
        }

        protected override void AssertValidMessage(IMessage message)
        {
            ITextMessage textMessage = (ITextMessage) message;
            String text = textMessage.Text;
            Console.WriteLine("Received message with text: " + text);
            Assert.AreEqual(expected, text, "the message text");
        }
    }
}