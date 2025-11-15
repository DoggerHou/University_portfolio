using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Laba_2__IP_TCP
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {

        List<ServerUser> users = new List<ServerUser>();
        int nextID = 1;

        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextID,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextID++;


            SendMessage(user.Name + " подключился к чату.", 0);
            users.Add(user);
            return user.ID;
        }


        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage(user.Name + " Покинул чат", 0);
            }
        }


        public void SendMessage(string msg, int id)
        {
            foreach (var u in users)
            {
                string answer = "[" + DateTime.Now.ToShortTimeString() + "]";

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += user.Name + ": ";
                }
                answer += msg;

                u.operationContext.GetCallbackChannel<IServiceChatCallback>().MessageCallback(answer);

            }
        }
    }
}
