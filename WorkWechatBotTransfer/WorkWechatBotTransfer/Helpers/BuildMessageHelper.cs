using Newtonsoft.Json;
using WorkWechatBotTransfer.Models;

namespace WorkWechatBotTransfer.Helpers;

public class BuildMessageHelper
{
    public static string BuildMessage(string requestJson)
    {
        var content = "";
        if (string.IsNullOrEmpty(requestJson)) return "";
        dynamic requestData = JsonConvert.DeserializeObject<dynamic>(requestJson);
        if (requestData == null) return "";

        switch (requestData.object_kind.ToString())
        {
            case "push":
                content = BuildPushMessage(requestData);
                break;
            case "merge_request":
                content = BuildMergeRequestMessage(requestData);
                break;
        }


        var message = new MarkdownMessage();
        message.msgtype = "markdown";
        message.markdown = new MarkdownContent { content = content };

        return JsonConvert.SerializeObject(message);
    }

    private static string BuildPushMessage(dynamic requestData)
    {
        var commits = "";
        if (requestData.commits != null)
        {
            foreach (var item in requestData.commits)
            {
                commits +=
                    $"> [{item.id.ToString().Substring(0, 8)}]({item.url})：{item.message.ToString().Replace("\n", "\n> ")}";
            }
        }

        return
            $"{requestData.user_name} pushed to [{requestData.project.path_with_namespace}]({requestData.project.web_url}) 的分支 {requestData["ref"]}\n {commits}";
    }

    private static string BuildMergeRequestMessage(dynamic requestData)
    {
        var action = "";
        if (requestData.object_attributes.action != null)
        {
            switch (requestData.object_attributes.action.ToString())
            {
                case "open":
                    action = "创建了";
                    break;
                case "merge":
                    action = "合并了";
                    break;
                case "update":
                    action = "更新了";
                    break;
                case "approved":
                    action = "批准了";
                    break;
                case "unapproved":
                    action = "撤销了批准";
                    break;
            }
        }

        return
            $"{requestData.user.name} {action} [MR !{requestData.object_attributes.iid}]({requestData.object_attributes.url}) in [{requestData.project.path_with_namespace}]({requestData.project.web_url})：**{requestData.object_attributes.title}**";
    }
}