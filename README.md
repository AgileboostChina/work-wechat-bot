# work-wechat-bot
## 实现了Gitlab Push 和 MergeRequest消息转发至企业微信机器人

### 1 部署webapi站点
### 2 在gitlab-webhooks中添加http://{host或ip:port}/api/GitLab/Transfer?key={企业微信机器人key}
### 3 勾选推送事件和合并请求事件
### 4 保存
### 5 测试，选择Push events或Merge requests events