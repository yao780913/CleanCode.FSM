# Agile Principles, Patterns, and Practices in C# (無瑕的程式碼) 
## Chapter36: STATE 模式
### 巢狀 (switch / case 實作)
- `FSM.SwitchCase`
- 巢狀 (switch / case 實作)
- 最直接的實作方式, 但若情境越來越複雜, 會變得難以維護

### 遷移表
- `FSM.Transitions`
- pros: 容易了解整體狀態機的邏輯, 簡潔, 易於維護
- cons: 因需要遍歷整張遷移表 (`transitions`), 若狀態過多時, 可能會有效能問題, 
- 
### State Pattern
- `FSM.StatePattern`
- pros: 徹底分離了狀態機的邏輯與動作。
- cons: 邏輯分散到各個 State, 無法一眼看穿整體狀態機的邏輯
